document.addEventListener('DOMContentLoaded', function () {
    document.body.addEventListener('click', function (event) {
        const target = event.target.closest('a');

        if (target && target.classList.contains('btn')) {
            const id = target.getAttribute('data-id');
            const action = target.getAttribute('data-action');
            const controller = target.getAttribute('data-controller');

            if (action && controller) {
                let url = `/${controller}/${action}`;
                if (id) {
                    url += `/${id}`;
                }
                window.location.href = url;
                event.preventDefault();
                event.stopPropagation();
            }
        }
    });
});
