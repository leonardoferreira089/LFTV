document.addEventListener('DOMContentLoaded', function () {
    const showDetails = document.getElementById('show-details');

    // Esta é uma simulação de como os dados do programa atual podem ser carregados.
    // Você pode substituir este código por uma chamada AJAX para um servidor que fornece os dados reais.
    const currentShow = {
        title: 'Jornal X',
        time: '19h40',
        description: 'Notícias do dia.'
    };

    showDetails.innerHTML = `<h2>${currentShow.title}</h2>
                             <p>${currentShow.time}</p>
                             <p>${currentShow.description}</p>`;
});

document.addEventListener('DOMContentLoaded', function () {
    const loginForm = document.getElementById('login-form');
    const loginError = document.getElementById('login-error');

    loginForm.addEventListener('submit', function (event) {
        event.preventDefault();

        const username = loginForm.username.value;
        const password = loginForm.password.value;

        // Simulação de verificação de nome de usuário e senha
        // Em um cenário real, você faria uma chamada AJAX para um servidor que verificaria as credenciais
        const validCredentials = {
            'LF089': 'Leo1234',
            'user': 'password'
        };

        if (validCredentials[username] && validCredentials[username] === password) {
            window.location.href = 'Admin.html'; // Redireciona para a página de administrador
        } else {
            loginError.style.display = 'block';
        }
    });
});
