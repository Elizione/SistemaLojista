// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var script = document.createElement('script');
script.src = 'https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js';
script.type = 'text/javascript';
document.getElementsByTagName('head')[0].appendChild(script);


//Máscara dos campos CPFCNPJ - TELEFONE - INSCRICAOESTADUAL
$().ready(function () {
    $('#CPFCNPJ').mask('000.000.000-00', { reverse: true });
    $('#TipoPessoa').change(function () {
        var tipoPessoa = $(this).val();
        if (tipoPessoa === 'Física') {
            $('#CPFCNPJ').mask('000.000.000-00', { reverse: true });
        } else if (tipoPessoa === 'Jurídica') {
            $('#CPFCNPJ').mask('00.000.000/0000-00', { reverse: true });
        }
    });

    $('#Telefone').change(function () {
        var telefone = $(this).val();
        $('#Telefone').mask('(00)00000-0000');
    });

    $('#InscricaoEstadual').change(function () {
        var telefone = $(this).val();
        $('#InscricaoEstadual').mask('000.000.000-000');
    });
});



//Lógica dos campos 

document.addEventListener('DOMContentLoaded', function () {
    var isentoCheckbox = document.getElementById('Isento');
    var inscricaoEstadualInput = document.getElementById('InscricaoEstadual');

    isentoCheckbox.addEventListener('change', function () {
        if (isentoCheckbox.checked) {
            inscricaoEstadualInput.disabled = true;
        } else {
            inscricaoEstadualInput.disabled = false;
        }
    });

    if (isentoCheckbox.checked) {
        inscricaoEstadualInput.disabled = true;
    }
});

document.addEventListener('DOMContentLoaded', function () {
    var tipoPessoaSelect = document.getElementById('TipoPessoa');
    var generoContainer = document.getElementById('GeneroContainer');
    var dataNascimentoContainer = document.getElementById('DataNascimentoContainer');

    function toggleFields() {
        if (tipoPessoaSelect.value === 'Física') {
            generoContainer.style.display = 'block';
            dataNascimentoContainer.style.display = 'block';
        } else {
            generoContainer.style.display = 'none';
            dataNascimentoContainer.style.display = 'none';
        }
    }

    tipoPessoaSelect.addEventListener('change', toggleFields);

    toggleFields();
});


//
