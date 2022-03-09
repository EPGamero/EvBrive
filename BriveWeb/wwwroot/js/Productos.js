$(document).ready(function () {
    loadData();
});


function loadData() {
    $.ajax({
        url: "/Productos/GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.idProducto + '</td>';
                html += '<td>' + item.Nombre + '</td>';
                html += '<td>' + item.Precio + '</td>';
                html += '<td>' + item.Descripcion + '</td>';
                html += '<td>' + item.Marca + '</td>';
                html += '<td>' + item.Existencia + '</td>';
                html += '<td>' + item.Proveedor.idProveedor + '</td>';
                html += '<td>' + item.Categoria.idCategoria + '</td>';
                html += '<td><a href="#" onclick="return GetById(' + item.idProducto + ')">Edit</a> | <a href="#" onclick="Delete(' + item.idProducto + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetById(Id) {
    var prodObj = {
        DepartamentId: Id,
    };
    $.ajax({
        url: "/Productos/GetById",
        data: JSON.stringify(prodObj),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            $('#idProducto').val(result.idProducto);
            $('#NombreP').val(result.Nombre);
            $('#PrecioP').val(result.Precio);
            $('#DescripcionP').val(result.Descripcion);
            $('#MarcaP').val(result.Marca);
            $('#ExistenciaP').val(result.Existencia);
            $('#ProveedorP').val(result.Proveedor.idProveedor);
            $('#CategoriaP').val(result.Categoria.idCategoria);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}



function Update() {
        var prodObj = {
            idProducto: $('#idProducto').val(),
            Nombre: $('#NombreP').val(),
            Precio: $('#PrecioP').val(),
            Descripcion: $('#DescripcionP').val(),
            Marca: $('#MarcaP').val(),
            Existencia: $('#ExistenciaP').val(),
            Proveedor.idProveedor: $('#ProveedorP').val(),
            Categoria.idCategoria: $('#CategoriaP').val(),
        };
        $.ajax({
            url: "/Productos/Update",
            data: JSON.stringify(prodObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                loadData();
                $('#myModal').modal('hide');
                $('#DepartmentId').val("");
                $('#DepartmentName').val("");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
  
}



function Delete(Id) {
    var prodObj = {
        idProducto: Id,
    };
    var ans = confirm("¿Estás seguro de eliminar este producto del inventario?");
    if (ans) {
        $.ajax({
            url: "/Productos/Delete",
            data: JSON.stringify(prodObj),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}


function Add() {
    var prodObj = {
        Nombre: $('#NombreP').val(),
        Precio: $('#PrecioP').val(),
        Descripcion: $('#DescripcionP').val(),
        Marca: $('#MarcaP').val(),
        Existencia: $('#ExistenciaP').val(),
        Proveedor.idProveedor: $('#ProveedorP').val(),
        Categoria.idCategoria: $('#CategoriaP').val(),
    };
        $.ajax({
            url: "/Department/Add",
            data: JSON.stringify(prodObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                location.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    
}

function clearTextBox() {
    $('#myModalLabel').html('Agregar Producto');
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}













