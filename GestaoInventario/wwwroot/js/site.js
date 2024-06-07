document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.editar').forEach(button => {
        button.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            window.location.href = `/Produtos/Edit/${id}`;
        });
    });

    document.querySelectorAll('.detalhes').forEach(button => {
        button.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            window.location.href = `/Produtos/Details/${id}`;
        });
    });

    document.querySelectorAll('.eliminar').forEach(button => {
        button.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            window.location.href = `/Produtos/Delete/${id}`;
        });
    });

    document.querySelector('.btn-primary').addEventListener('click', function () {
        window.location.href = '/Produtos/Create';
    });

    document.querySelector('a[href="/Produtos"]').addEventListener('click', function () {
        window.location.href = '/Produtos';
    });
});
