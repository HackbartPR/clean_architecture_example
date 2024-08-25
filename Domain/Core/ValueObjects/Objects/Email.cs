namespace Domain.Core.ValueObjects.Objects;

internal class Email
{
	public string Address { get; private set; }

	public Email(string address)
	{
		Address = address;
		Validate();
	}

	private void Validate()
	{
		if (string.IsNullOrEmpty(Address))
			throw new ArgumentNullException(nameof(Address));

		//Alguma outra lógica para validar e-mails
	}

	public void Alter(string address)
	{
		Address = address;
		Validate();
	}
}
