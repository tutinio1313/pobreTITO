/*jslint browser */
"use strict";
// eslint-disable-next-line
function canPost()
{
  var inputs = document.getElementsByTagName('input');
  var state = true;

  for (let index = 0; index < inputs.length; index++) {
    if(index == 0)
    {
      if(inputs[index].value.includes('@'))
      {
        state = true;
      }
      else
      {
        state = false;
      }
    }
    
    if(inputs[index].value == "")
    {
      state = false;
    }    
  }
  var button = document.getElementById('submit');
  if(state)
  {    
    button.removeAttribute('disabled');    
  }
  else
  {
    const attribute = document.createAttribute('disabled');
    button.setAttributeNode(attribute);
  }
}
