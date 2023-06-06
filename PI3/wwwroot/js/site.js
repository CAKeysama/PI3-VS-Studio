var senhaInput = document.getElementById("senha");
var confSenhaInput = document.getElementById("confSenha");
var mensagem = document.getElementById("mensagem");

senhaInput.addEventListener("input", verificarSenha);
confSenhaInput.addEventListener("input", verificarSenha);

function verificarSenha() {
    var senha = senhaInput.value;
    var confSenha = confSenhaInput.value;

    if (senha === confSenha) {
        mensagem.textContent = "As senhas coincidem!";
    } else {
        mensagem.textContent = "As senhas não coincidem!";
    }
}