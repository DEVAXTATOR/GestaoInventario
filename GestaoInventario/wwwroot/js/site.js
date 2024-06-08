document.addEventListener('DOMContentLoaded', function () {
    document.body.addEventListener('click', function (event) {
        if (event.target.matches('.editar, .editar *')) {
            const id = event.target.closest('.editar').getAttribute('data-id');
            window.location.href = `/Produtos/Edit/${id}`;
        } else if (event.target.matches('.detalhes, .detalhes *')) {
            const id = event.target.closest('.detalhes').getAttribute('data-id');
            window.location.href = `/Produtos/Details/${id}`;
        } else if (event.target.matches('.eliminar, .eliminar *')) {
            const id = event.target.closest('.eliminar').getAttribute('data-id');
            window.location.href = `/Produtos/Delete/${id}`;
        }
    });
});
