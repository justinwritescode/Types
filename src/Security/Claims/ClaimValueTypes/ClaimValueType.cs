namespace JustinWritesCode.Security.Claims;

public class ClaimValueType : UriDescriptionTuple, IValidator<C>
{
	public ClaimValueType(string uri, string? description = null, Action<InlineValidator<C>>? setupValidator = null) : this(new Uri(uri), description, CreateValidator(setupValidator)) { }
	public ClaimValueType(string uri, string? description = null, IValidator<C>? validator = null) : this(new Uri(uri), description, validator) { }
	public ClaimValueType(Uri uri, string? description = null, Action<InlineValidator<C>>? setupValidator = null) : this(uri, description, CreateValidator(setupValidator)) { }
	public ClaimValueType(Uri uri, string? description = null, IValidator<C>? validator = null) : base(uri, description)
	{
		Validator = validator;
	}

	private static IValidator<C>? CreateValidator(Action<InlineValidator<C>>? setup = null)
	{
		if(setup == null) return null;
		var validator = new InlineValidator<C>();
		setup(validator);
		return validator;
	}
	private IValidator<C>? Validator { get; }

	public override string ToString() => Uri.ToString();

	public bool CanValidateInstancesOfType(Type type) => type.IsAssignableFrom(typeof(C));

	public IValidatorDescriptor CreateDescriptor() => Validator.CreateDescriptor();

	public FvResult Validate(C instance) => Validator.Validate(instance);
	public FvResult Validate(IValidationContext context) => Validator.Validate(new ValidationContext<C>(context.InstanceToValidate as C));
	public Task<FvResult> ValidateAsync(C instance, CancellationToken cancellation = default) => Validator.ValidateAsync(instance, cancellation);
	public Task<FvResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default) => Validator.ValidateAsync(new ValidationContext<Claim>(context.InstanceToValidate as Claim), cancellation);

	public static implicit operator string(ClaimValueType claimValueType) => claimValueType.Uri.ToString();
	public static implicit operator uri?(ClaimValueType claimValueType) => claimValueType.Uri;
	public static implicit operator ClaimValueType(uri claimValueType) => (claimValueType);
	public static implicit operator ClaimValueType((string, string, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, tuple.Item2, tuple.Item3);
	public static implicit operator ClaimValueType((uri, string, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, tuple.Item2, tuple.Item3);
	public static implicit operator ClaimValueType((string, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, null, tuple.Item2);
	public static implicit operator ClaimValueType((uri uri, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, null, tuple.Item2);
	// public static implicit operator ClaimValueType((string, string, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, tuple.Item2, tuple.Item3);
	// public static implicit operator ClaimValueType((uri uri, string, IValidator<Claim>) tuple) => new ClaimValueType(tuple.Item1, tuple.Item2, tuple.Item3);
}
