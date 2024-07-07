// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteCandidate(idCandidate) {
    $.ajax({
        url: '/Candidate/Delete',
        type: 'DELETE',
        data: {
            idCandidate: idCandidate,
        },
        success: function (result) {
            // Redirigir a la página deseada después de eliminar
            window.location.href = '/Candidate/Index';
        },
        error: function (error) {
            // Manejar el error
            console.error("Error deleting experience:", error);
        }
    });
}

function deleteExperience(idCandidate, idExperience) {
    $.ajax({
        url: '/Experience/Delete',
        type: 'POST',
        data: {
            idCandidate: idCandidate,
            idExperience: idExperience
        },
        success: function (result) {
            // Redirigir a la página deseada después de eliminar
            window.location.href = '/Candidate/ExperiencesByCandidate?idCandidate=' + idCandidate;
        },
        error: function (error) {
            // Manejar el error
            console.error("Error deleting experience:", error);
        }
    });
}