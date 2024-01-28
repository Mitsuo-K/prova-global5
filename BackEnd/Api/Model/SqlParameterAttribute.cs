namespace Api.Model
{
    [AttributeUsage(AttributeTargets.All)]
    public class SqlParameterAttribute : Attribute
    {
        private Boolean isParameter;
        public SqlParameterAttribute(Boolean isParameter)
        {
            this.isParameter = isParameter;
        }

        public virtual bool IsParameter
        {
            get { return isParameter; }
            set { isParameter = value; }
        }
    }
}
