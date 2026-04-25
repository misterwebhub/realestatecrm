
     $.validate({
    lang: 'es'
  });
  
            
 $(document).ready(function(){
  
    $(".zoom").hover(function(){
		
		$(this).addClass('transition');
	}, function(){
        
		$(this).removeClass('transition');
	});
});
 
 
          
          function CopyToClipboard(containerid) {
  if (document.selection) {
    var range = document.body.createTextRange();
    range.moveToElementText(document.getElementById(containerid));
    range.select().createTextRange();
    document.execCommand("copy");

  } else if (window.getSelection) {
    var range = document.createRange();
    range.selectNode(document.getElementById(containerid));
    window.getSelection().addRange(range);
    document.execCommand("copy");
    //alert("text copied, copy in the text-area")
  }
}
       
       
      function countChar(val) {
        var len = val.value.length;
        var max = 400;
        if (len >= max) {
    $('#charNum').text('0 characters left');
  } else {
    var char = max - len;
    $('#charNum').text(char + ' characters left');
  }
  
  
      };


  $(document).ready(function(){
    $('#galleryImage').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#galleryImageName").html(fileName+"-"+msize);
    });
  
    $('#galleryMedia').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#galleryMediaName").html(fileName+"-"+msize);
    });
  
    $('#ProfileImage').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#ProfileImageName").html(fileName+"-"+msize);
    });
  
    $('#IDImage').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#IDImageName").html(fileName+"-"+msize);
    });
  
    $('#panImage').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#panImageName").html(fileName+"-"+msize);
    });
  
    $('#BankImage').change(function(e){
      var fileName = e.target.files[0].name;
      var fileSize = e.target.files[0].size;
      var fSExt = new Array('Bytes', 'KB', 'MB', 'GB');
      fSize = fileSize; i=0;while(fSize>900){fSize/=1024;i++;}
      var msize=(Math.round(fSize*100)/100)+' '+fSExt[i];
      $("#BankImageName").html(fileName+"-"+msize);
    });
  });
    
    
    
$(".js-example-tags").select2({
  tags: true,
  theme: 'bootstrap4',
  
});

    
$(".selectInterest").select2({
  theme: 'bootstrap4',
  placeholder: 'Type Student Name or ID',
});


function setInputFilter(textbox, inputFilter) {
  ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function(event) {
    textbox.addEventListener(event, function() {
      if (inputFilter(this.value)) {
        this.oldValue = this.value;
        this.oldSelectionStart = this.selectionStart;
        this.oldSelectionEnd = this.selectionEnd;
      } else if (this.hasOwnProperty("oldValue")) {
        this.value = this.oldValue;
        this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
      } else {
        this.value = "";
      }
    });
  });
}

setInputFilter(document.getElementById("inputMobile"), function(value) {
  return /^\d*$/.test(value); });
setInputFilter(document.getElementById("inputPincode"), function(value) {
  return /^\d*$/.test(value); });
setInputFilter(document.getElementById("inputTempPincode"), function(value) {
  return /^\d*$/.test(value); });
setInputFilter(document.getElementById("inputAadhaar"), function(value) {
  return /^\d*$/.test(value); });

setInputFilter(document.getElementById("inputFamilyMemberName"), function(value) {
  return /^[a-z ]*$/i.test(value); });
setInputFilter(document.getElementById("inputOccupation"), function(value) {
  return /^[a-z ]*$/i.test(value); });
setInputFilter(document.getElementById("inputNationality"), function(value) {
  return /^[a-z ]*$/i.test(value); });
setInputFilter(document.getElementById("inputCity"), function(value) {
  return /^[a-z ]*$/i.test(value); });
setInputFilter(document.getElementById("inputTempCity"), function(value) {
  return /^[a-z ]*$/i.test(value); });
setInputFilter(document.getElementById("inputPAN"), function(value) {
  return /^[0-9A-Z]*$/i.test(value); });
setInputFilter(document.getElementById("inputNomineeAge"), function(value) {
  return /^\d*$/.test(value) && (value === "" || parseInt(value) <= 100); });