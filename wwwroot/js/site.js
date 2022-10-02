/*jslint browser */
"use strict";
// eslint-disable-next-line
function canPost() {
  var state = GetState();
  var button = document.getElementById("submit");

  if (state) {
    button.removeAttribute("disabled");
  } else {
    const attribute = document.createAttribute("disabled");
    button.setAttributeNode(attribute);
  }
}

function GetState() {
  var inputs = document.getElementsByTagName("input");
  var form = document.getElementById("LoginForm");
  var state = NotEmpty(inputs);
  if (form != null && state) {
    state = CanLogin(inputs);
  } else {
    if (state) {
      state = CanRegister(inputs);
    }
  }
  return state;
}
function CanRegister(inputs) {
  if (!inputs[0].value.includes("@")) {
    ShowErrorMessage("Oops, parece que el email es erroneo.");
    return false;
  }

  if (!inputs[1].value.includes("@")) {
    ShowErrorMessage("Oops, parece que el email de confirmación es erroneo.");
    return false;
  }

  if (inputs[0].value != inputs[1].value) {
    ShowErrorMessage("Los emails ingresados no son iguales, por favor revise.");
    return false;
  }

  if (inputs[5].value.length < 8) {
    ShowErrorMessage("La contraseña debe ser de al menos 8 caracteres.");
    return false;
  }

  if (inputs[5].value != inputs[6].value) {
    ShowErrorMessage("Las contraseñas no son iguales, por favor revise");
    return false;
  }

  return true;
}

function CanLogin(inputs) {
  if (!inputs[0].value.includes("@")) {
    ShowErrorMessage("Oops, parece que el email ingresado es incorrecto.");
    return false;
  }
  return true;
}

function NotEmpty(inputs) {
  for (let index = 0; index < inputs.length; index++) {
    if (inputs[index].value == "") {
      return false;
    }
  }
  return true;
}

async function ShowErrorMessage(message) {
  var element = document.getElementById("ErrorMessages");

  element.appendChild(message);

  setTimeout(() => {
    element.removeChild(element.firstElementChild);
  }, 3000);
}
