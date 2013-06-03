namespace AmplaTools.ProjectCreate.Validation
{
    public abstract class ValidationTestFixture<T> : TestFixture
    {
        protected T Validation;
        protected override void OnSetUp()
        {
            base.OnSetUp();
            Messages = new ValidationMessages();
            Validation = Create(Messages);
        }

        protected abstract T Create(ValidationMessages validationMessages);
        protected ValidationMessages Messages { get; private set; }


        
    }
}