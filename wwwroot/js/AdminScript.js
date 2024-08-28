document.addEventListener('DOMContentLoaded', function () {
    const passwordInput = document.getElementById('password');
    const togglePassword = document.getElementById('togglePassword');
    // Grab the values from data attributes if present
    const messageType = document.body.dataset.messageType || '';
    const messageText = document.body.dataset.messageText || '';

    if (messageType === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: messageText
        });
    }
    else if (messageType === "success") {
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: messageText
        });
    }

    if (passwordInput && togglePassword) {
        togglePassword.addEventListener('click', () => {
            // Toggle password visibility
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                togglePassword.classList.remove('fa-eye-slash');
                togglePassword.classList.add('fa-eye');
            } else {
                passwordInput.type = 'password';
                togglePassword.classList.remove('fa-eye');
                togglePassword.classList.add('fa-eye-slash');
            }
        });
    }
});


