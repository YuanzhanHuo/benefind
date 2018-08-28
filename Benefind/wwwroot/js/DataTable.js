// Add DataTable() to benefits table

$(document).ready(function () {
    $('#tb-benefits').DataTable({
        "searching": true
    });
    $('.dataTables_length').addClass('bs-select');
});
