using UnityEngine;

namespace Tools
{
    [System.Serializable]
    public struct DecimalSerialized : ISerializationCallbackReceiver
    {
        public decimal value;
        [SerializeField]
        private string data;

        public void OnBeforeSerialize()
        {
            data = value.ToString();
        }

        public void OnAfterDeserialize()
        {
            value = decimal.TryParse(data, out decimal result) ? result : 0;
        }

        public static implicit operator decimal(DecimalSerialized d)
        {
            return d.value;
        }

        public static implicit operator DecimalSerialized(decimal d)
        {
            return new DecimalSerialized() { value = d };
        }

        public override string ToString()
        {
            return value.ToString();
        }

    }
}
