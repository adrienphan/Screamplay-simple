// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ModalChangeContent(id) {
    let modalTitle = document.getElementById("DetailsModalLabel");
    modalTitle.innerHTML = "blup";

    let modalBody = document.getElementById("DetailsModalBody");
    modalBody.innerHTML = "blboblboblbolbobolo";
}