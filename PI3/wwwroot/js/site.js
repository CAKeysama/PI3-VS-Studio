/*var senhaInput = document.getElementById("senha");
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
*/
const nome = document.getElementById("nome");
const email = document.getElementById("email");
const telefone = document.getElementById("telefone");
const senha = document.getElementById("senha");
const csenha = document.getElementById("csenha");

csenha.addEventListener("input", validar);

function validar() {

    if (senha.value === "" || email.value === "" || telefone.value === "" || senha.value === "" || csenha.value === "" || senha.value != csenha.value) {
        Swal.fire(
            icon: 'error',
            title: 'Opa!',
            text: 'Algumas informações estão faltando',
        )
    } 


}