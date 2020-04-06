$(document).ready(function () {

  $('#tabemployes').DataTable({
    "processing": true, 
    "serverSide": true, 
    "filter": true, 
    "orderMulti": false,  
    "sScrollY": "200px",
    "bPaginate": false,
    "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
    "ajax": {
      "url": "/Administration/Employe/_chargement",
      "type": "GET",
      "datatype": "json"
    },
    "columnDefs":
      [{
        "targets": [0],
        "visible": false,
        "searchable": false
      }],  
    "columns": [
      { "data": "id", "name": "id", "autoWidth": true },
      { "data": "nom", "name": "Nom Employe", "autoWidth": true },
      { "data": "societe", "name": "Societe", "autoWidth": true },
      { "data": "typeEmploye", "name": "TypeEmploye", "autoWidth": true },
      { "data": "matricule", "name": "Matricule", "autoWidth": true },
      { "data": "email", "name": "E-mail", "autoWidth": true },
      { "data": "telephone1", "name": "Telephone", "autoWidth": true },
      {
        "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Administration/Employe/Edit/' + full.id + '">Editer</a>'; }
      },
      {
        "render": function (data, type, full, meta) { return '<a class="btn btn-danger" href="/Administration/Employe/Delete/' + full.id + '">Supprimer</a>'; }
      },  
    ]
  });
});

function SuppressionDonnees(id) {
  if (confirm("Confirmer la suppression ...?")) {
    Suppresssion(id);
  }
  else {
    return false;
  }
}
//data: null, render: function (data, type, row) {
//return "<a href='#' class='btn btn-danger' onclick=SuppressionDonnees('" + row.id + "'); >Supprimer</a>";
//}

function Suppresssion(id) {
  var url = '@Url.Content("~/")' + "Administration/Employe/Delete";

  $.post(url, { id: id }, function (data) {
    if (data) {
      oTable = $('#tabemployes').DataTable();
      oTable.draw();
    }
    else {
      alert("Something Went Wrong!");
    }
  });
}  