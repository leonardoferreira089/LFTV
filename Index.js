document.addEventListener("DOMContentLoaded", function () {
    // Defina a programação de TV
    const schedule = [
        {
            name: "Programa da Manhã",
            description: "Um programa matinal com notícias e entretenimento.",
            startTime: "06:00",
            endTime: "08:00",
            day: 0  // Domingo
        },
        {
            name: "Jornal Local",
            description: "Notícias locais e reportagens.",
            startTime: "12:00",
            endTime: "13:00",
            day: 0  // Domingo
        },
        {
            name: "Novela das 7",
            description: "A emocionante novela das sete.",
            startTime: "19:00",
            endTime: "20:00",
            day: 0  // Domingo
        },
        {
            name: "Filme de Domingo",
            description: "Um filme especial de domingo.",
            startTime: "21:00",
            endTime: "23:00",
            day: 0  // Domingo
        }
    ];

    function getCurrentShow(schedule) {
        const now = new Date();
        const nowHours = now.getHours();
        const nowMinutes = now.getMinutes();
        const nowDay = now.getDay();

        for (const show of schedule) {
            const [startHours, startMinutes] = show.startTime.split(':').map(Number);
            const [endHours, endMinutes] = show.endTime.split(':').map(Number);

            if (
                show.day === nowDay &&
                (nowHours > startHours || (nowHours === startHours && nowMinutes >= startMinutes)) &&
                (nowHours < endHours || (nowHours === endHours && nowMinutes < endMinutes))
            ) {
                return show;
            }
        }

        return null;
    }

    const currentShow = getCurrentShow(schedule);

    if (currentShow) {
        document.getElementById("show-details").innerHTML = `
            <h3>${currentShow.name}</h3>
            <p>${currentShow.description}</p>
        `;
    } else {
        document.getElementById("show-details").innerHTML = "<p>Nenhum programa está sendo exibido no momento.</p>";
    }
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
