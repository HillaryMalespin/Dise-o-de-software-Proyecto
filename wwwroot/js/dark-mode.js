document.addEventListener('DOMContentLoaded', function () {
    const darkModeToggle = document.getElementById('dark-mode-toggle');

    // Configuración de colores para íconos
    const iconFilters = {
        dark: {
            themeIcon: 'brightness(0) saturate(100%) invert(88%) sepia(10%) saturate(566%) hue-rotate(183deg) brightness(89%) contrast(87%)',
            socialIcon: 'brightness(0) invert(1)' // Blanco o usar el mismo que themeIcon si prefieres
        },
        light: {
            themeIcon: 'brightness(0) invert(0)', // Color original del SVG
            socialIcon: 'brightness(0) invert(1)' // Blanco
        }
    };

    // Función para actualizar íconos
    function updateIcons(isDark) {
        const mode = isDark ? 'dark' : 'light';

        // Ícono del tema (sol/luna)
        const themeIcons = document.querySelectorAll('.theme-icon');
        themeIcons.forEach(icon => {
            icon.style.filter = iconFilters[mode].themeIcon;
        });

        // Íconos sociales
        const socialIcons = document.querySelectorAll('.social-icon, .social-icons img[src$=".svg"]');
        socialIcons.forEach(icon => {
            icon.style.filter = iconFilters[mode].socialIcon;
        });
    }

    // Función para aplicar/sacar modo oscuro
    function setDarkMode(isDark) {
        if (isDark) {
            document.body.classList.add('dark-mode');
        } else {
            document.body.classList.remove('dark-mode');
        }
        updateIcons(isDark);
    }

    // Inicialización
    function initDarkMode() {
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        const savedMode = localStorage.getItem('darkMode');

        // Priorizar configuración guardada sobre preferencias del sistema
        const initialMode = savedMode ? savedMode === 'dark' : prefersDark;
        setDarkMode(initialMode);
    }

    // Evento click para el botón
    darkModeToggle.addEventListener('click', function () {
        const isDark = !document.body.classList.contains('dark-mode');
        localStorage.setItem('darkMode', isDark ? 'dark' : 'light');
        setDarkMode(isDark);
    });

    // Escuchar cambios del sistema
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
        if (!localStorage.getItem('darkMode')) {
            setDarkMode(e.matches);
        }
    });

    // Iniciar
    initDarkMode();
});