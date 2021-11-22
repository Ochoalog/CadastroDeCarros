var tbody = document.querySelector('table tbody');
var carro = {};
var findCpf = false;

function register() {
  carro.Marca = document.querySelector('#marca').value;
  carro.Modelo = document.querySelector('#modelo').value;
  carro.Placa = document.querySelector('#placa').value;
  carro.Roda = document.querySelector('#roda').value;
  carro.Porta = document.querySelector('#porta').value;
  carro.Cor = document.querySelector('#cor').value;
  carro.Preco = document.querySelector('#preco').value;
  carro.Combustivel = document.querySelector('#combustivel').value;

  if (carro.Marca === '') {
    bootbox.alert("Preencha o campo Marca");
  } 
  else {
    if(carro.Placa === '') {
      bootbox.alert("Preencha o campo Placa.");
    }
    else if(carro.Cor === ''){
      bootbox.alert("Preencha o campo Cor.");
    }
    else if(carro.Porta === 0) {
      bootbox.alert("Preencha o campo Portas corretamente.");
    }
    else {
      if (carro.Id === undefined || carro.Id === 0) {
          saveCarros('POST', 0, carro);
      }
      else {
        saveCarros('PUT', carro.Id, carro);
      }
    }
  }
  loadCarros();
}

function newCarro() {
  var btnSave = document.querySelector('#btnSave');
  var title = document.querySelector('#title');

  document.querySelector('#marca').value = '';
  document.querySelector('#modelo').value = '';
  document.querySelector('#placa').value = '';
  document.querySelector('#roda').value = '';
  document.querySelector('#porta').value = '';
  document.querySelector('#cor').value = '';
  document.querySelector('#combustivel').value = '';
  document.querySelector('#preco').value = '';

  carro = {};

  btnSave.textContent = 'Cadastrar';
  btnCancel.textContent = 'Limpar';
  title.textContent = "Cadastrar carroe";
}

function cancel() {
  var btnSave = document.querySelector('#btnSave');
  var title = document.querySelector('#title');

  document.querySelector('#marca').value = '';
  document.querySelector('#modelo').value = '';
  document.querySelector('#placa').value = '';
  document.querySelector('#roda').value = '';
  document.querySelector('#porta').value = '';
  document.querySelector('#roda').value = '';
  document.querySelector('#cor').value = '';
  document.querySelector('#combustivel').value = '';
  document.querySelector('#preco').value = '';

  carro = {};

  btnSave.textContent = 'Cadastrar';
  btnCancel.textContent = 'Limpar';
  title.textContent = "Cadastrar carroe";
}

function loadCarros() {
  tbody.innerHTML = '';

  var xhr = new XMLHttpRequest();

  xhr.open('GET', `https://localhost:44312/api/carro/GetAll`, true)

  xhr.onreadystatechange = function () {
    if (this.readyState == 4) {
      if (this.status == 200) {
        var carros = JSON.parse(this.responseText);
        for (var index in carros) {
          insertLine(carros[index]);
        }
      }
      else if (this.status == 500) {
        var error = JSON.parse(this.responseText);
      }
    }
  }
  xhr.send();
}

function saveCarros(method, id, body) {
  var xhr = new XMLHttpRequest();

  if (id === 0) {
    id = '';
  }

  xhr.open(method, `https://localhost:44312/api/carro/${id}`, true);

  xhr.setRequestHeader('content-type', 'application/json');
  xhr.send(JSON.stringify(body));
}

loadCarros();

function editCarro(_carro) {
  var btnSave = document.querySelector('#btnSave');
  var title = document.querySelector('#title');


  document.querySelector('#marca').value = _carro.Marca;
  document.querySelector('#modelo').value = _carro.Modelo;
  document.querySelector('#placa').value = _carro.Placa;
  document.querySelector('#roda').value = _carro.Roda;
  document.querySelector('#porta').value = _carro.Porta;
  document.querySelector('#cor').value = _carro.Cor;
  document.querySelector('#combustivel').value = _carro.Combustivel;
  document.querySelector('#preco').value = _carro.Preco;

  btnSave.textContent = 'Salvar';
  btnCancel.textContent = 'Cancelar';
  title.textContent = `Editar carroe: ${_carro.Name}`;

  carro = _carro;
}

function deleteCarro(id) {
  var xhr = new XMLHttpRequest();

  xhr.open('DELETE', `https://localhost:44312/api/carro/Delete/${id}`, false);

  xhr.send();
}

function deleteAndLoad(carro) {
  bootbox.confirm({
    message: `Tem certeza que deseja excluir ${carro.Placa}?`,
    buttons: {
      confirm: {
        label: 'Sim',
        className: 'btn-success'
      },
      cancel: {
        label: 'Não',
        className: 'btn-danger'
      }
    },
    callback: function (result) {
      if (result) {
        deleteCarro(carro.Id);
        loadCarros();
      }
    }
  });
}

function insertLine(carro) {
  var trow = `<tr>
  <td>${carro.Marca}</td>
  <td>${carro.Modelo}</td>
  <td>${carro.Placa}</td>
  <td>${carro.Cor}</td>
  <td>${carro.Combustivel}</td>
  <td>${carro.Preco}</td>
  <td>
  <button class="btn btn-warning" data-bs-dismiss="modal" data-bs-toggle="modal" data-bs-target="#modal" onclick='editCarro(${JSON.stringify(carro)})'>Editar</button> 
  <button class="btn btn-danger" data-bs-dismiss="modal" onclick='deleteAndLoad(${JSON.stringify(carro)})'>Deletar</button>
  </td>
  </tr>   
  `
  tbody.innerHTML += trow;
}


