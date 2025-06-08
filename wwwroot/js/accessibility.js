document.addEventListener('DOMContentLoaded', function () {
    const accessibilityBtn = document.getElementById('accessibility-btn');
    const accessibilityMenu = document.querySelector('.accessibility-menu');
    const closeMenuBtn = document.querySelector('.close-menu');

    // Toggle del menú de accesibilidad
    accessibilityBtn.addEventListener('click', function () {
        const isHidden = accessibilityMenu.hidden;
        accessibilityMenu.hidden = !isHidden;
    });

    closeMenuBtn.addEventListener('click', function () {
        accessibilityMenu.hidden = true;
    });

    // Funcionalidades de accesibilidad
    document.querySelector('.font-increase').addEventListener('click', function () {
        changeFontSize(1);
    });

    document.querySelector('.font-decrease').addEventListener('click', function () {
        changeFontSize(-1);
    });

    document.querySelector('.high-contrast').addEventListener('click', toggleHighContrast);
    document.querySelector('.reading-mode').addEventListener('click', toggleReadingMode);

    function changeFontSize(step) {
        const html = document.documentElement;
        const currentSize = parseFloat(window.getComputedStyle(html, null).getPropertyValue('font-size'));
        const newSize = currentSize + step;

        if (newSize >= 12 && newSize <= 24) { // Límites razonables
            html.style.fontSize = newSize + 'px';
        }
    }

    function toggleHighContrast() {
        document.body.classList.toggle('high-contrast-mode');
    }

    function toggleReadingMode() {
        document.body.classList.toggle('reading-mode');
        // Aquí puedes agregar más lógica para el modo lectura
    }
});