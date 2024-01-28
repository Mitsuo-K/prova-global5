namespace Api.Model.StoreProcedure
{
    [AttributeUsage(AttributeTargets.All)]
    public class SqlParameterAttribute : Attribute
    {
        private bool isParameter;
        public SqlParameterAttribute(bool isParameter)
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
