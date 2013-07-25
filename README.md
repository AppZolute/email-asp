email-asp
=========

ASP Web Service For Sending Email

Setup
=========

1. Enter SMTP Configuration at Web.config

2. Enjoy!

How to Use
=========

Just issue a normal AJAX request.

    jQuery.ajax({
      url: "/EmailApi/SendEmailService.asmx/SendEmail",
      type: "POST",
      data: {
        to: "test@example.com",
	subject: "Test Email",
	body: "It is an email"
      }
    });

Contributors
=========

pinglamb (from AppZolute)

