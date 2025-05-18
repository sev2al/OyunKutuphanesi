// Initialize Venobox
$('.venobox').venobox({
    bgcolor: '',
    overlayColor: 'rgba(6, 12, 34, 0.85)',
    closeBackground: '',
    closeColor: '#fff'
  });



function send_message(form) {
  const name = form.elements.name.value;
  const email = form.elements.email.value;
  const phone = form.elements.phone.value;
  const message = form.elements.message.value;

  const formData = new FormData();
  formData.append('subject', `${name}, akkarlojistik.com.tr'den eposta gönderdi.`);
  formData.append('message', `${email} \n${phone} \n${message}`);
  
  fetch('/duyurular/send_mail/', {
    method: 'POST',
    body: formData,
  }) 
  .then(response => { 
    if (!response.ok) {
      throw Error(response.statusText);
    }   
    alert('e-posta gönderildi')
    form.elements.email.value = ""
  })
  .catch(() => { 
    alert('Hata e-posta gönderilemedi!')
  });  
}

(function($) {
  "use strict";
  if ((getCookie("akkar_popup") == null) && new Date() < new Date("2022-12-31")) {
      $(window).on('load', function () {
          $('#exampleModal').modal('show');
          document.cookie = 'akkar_popup = seen; expires =' + add_time(new Date(), 1) + '';
      });
  }

})(jQuery);

function dismiss(){
  document.getElementById('dismiss').style.display='none';
};

function add_time(dt, n) {
  return new Date(dt.setHours(dt.getHours() + n));
}

function getCookie(name) {
  // Split cookie string and get all individual name=value pairs in an array
  var cookieArr = document.cookie.split(";");

  // Loop through the array elements
  for (var i = 0; i < cookieArr.length; i++) {
      var cookiePair = cookieArr[i].split("=");

      /* Removing whitespace at the beginning of the cookie name
      and compare it with the given string */
      if (name == cookiePair[0].trim()) {
          // Decode the cookie value and return
          return decodeURIComponent(cookiePair[1]);
      }
  }

  // Return null if not found
  return null;
}