# AutoEmailToSms
Send out text messages using SMTP relay services. You will need a valid email address and token for authorization to send.

Setup to use with Gmail

At the following link setup via the Other setup options -> Use the Gmail SMTP server
https://support.google.com/a/answer/176600?hl=en#zippy=%2Cuse-the-gmail-smtp-server

Use the following to then send a text via Gmail to an AT&T phone number.

	TextMessage textMessage = new TextMessage();
	textMessage.To = "XXXXXXXXX";
	textMessage.Body = "Hello World!";
	textMessage.EmailAuthenticate = "youremail@gmail.com";
	textMessage.Token = "sometokenfromgmail";
	textMessage.TextServiceProvider = TextServiceProvider.AttMms;
	textMessage.EmailServiceProvider = EmailServiceProvider.Gmail;

	try
	{
		textMessage.SendTextMessage(textMessage);
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
		throw;
	}
