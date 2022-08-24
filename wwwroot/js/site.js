/*jslint browser */
"use strict";
// eslint-disable-next-line
function canPost()
{
  var inputs = document.getElementsByTagName('input');
  var state = true;

  for (let index = 0; index < inputs.length; index++) {
    if(inputs[index].value == "")
    {
      state = false;
    }    
  }

  if(state)
  {
    var button = document.getElementById('submit');
    button.removeAttribute('disabled');    
  }
}
