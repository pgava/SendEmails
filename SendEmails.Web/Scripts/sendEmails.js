$(document).ready(function () {
  $('#contact_form').bootstrapValidator({
      // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
      feedbackIcons: {
        valid: 'glyphicon glyphicon-ok',
        invalid: 'glyphicon glyphicon-remove',
        validating: 'glyphicon glyphicon-refresh'
      },
      fields: {
        emailTo: {
          validators: {
            notEmpty: {
              message: 'Please supply to email address'
            },
            emailAddress: {
              message: 'Please supply a valid email address'
            }
          }
        },
        emailCc: {
          validators: {
            notEmpty: {
              message: 'Please supply CC email address'
            },
            emailAddress: {
              message: 'Please supply a valid email address'
            }
          }
        },
        emailBcc: {
          validators: {
            //notEmpty: {
            //    message: 'Please supply BCC email address'
            //},
            emailAddress: {
              message: 'Please supply a valid email address'
            }
          }
        },
        subject: {
          validators: {
            stringLength: {
              min: 1,
              max: 200,
              message: 'Please enter at least 1 characters and no more than 200'
            },
            notEmpty: {
              message: 'Please supply a subject of your email'
            }
          }
        },
        body: {
          validators: {
            stringLength: {
              min: 1,
              max: 500,
              message: 'Please enter at least 1 characters and no more than 500'
            },
            notEmpty: {
              message: 'Please supply a body message of your email'
            }
          }
        }
      }
    })
    .on('success.form.bv', function (e) {
      $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
      $('#contact_form').data('bootstrapValidator').resetForm();

      // Prevent form submission
      e.preventDefault();

      // Get the form instance
      var $form = $(e.target);

      // Get the BootstrapValidator instance
      var bv = $form.data('bootstrapValidator');

      // Use Ajax to submit form data
      $.post($form.attr('action'), $form.serialize(), function (result) {
        console.log(result);
      }, 'json');
    });
});

