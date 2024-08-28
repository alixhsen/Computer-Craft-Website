document.addEventListener('DOMContentLoaded', function (e) {
    const messageType = document.body.dataset.messageType || '';
    const messageText = document.body.dataset.messageText || '';

    if (messageType === "error") {
        e.preventDefault(); // Prevent form submission
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: messageText
        });
    } else if (messageType === "success") {
        e.preventDefault(); // Prevent form submission
        Swal.fire({
            icon: 'success',
            title: 'Success!',
            text: messageText
        });
    }

    const passwordInput = document.getElementById('password');
    const confirmPasswordInput = document.getElementById('confirmPassword');
    const registrationForm = document.getElementById('registrationForm');
    const lengthCheck = document.getElementById('lengthCheck');
    const numberCheck = document.getElementById('numberCheck');
    const capitalCheck = document.getElementById('capitalCheck');
    const characterCheck = document.getElementById('characterCheck');
    const specialCheck = document.getElementById('specialCheck');
    const confirmPasswordError = document.getElementById('confirmPasswordError');
    const togglePassword = document.getElementById('togglePassword');
    const toggleConfirmPassword = document.getElementById('toggleConfirmPassword');
    const nationalIdInput = document.getElementById('nationalnb');
    const nationalIdError = document.getElementById('nationalIdError');

    const validatePassword = () => {
        const password = passwordInput.value;
        let valid = true;

        const checks = [
            { regex: /.{8,}/, element: lengthCheck },
            { regex: /\d/, element: numberCheck },
            { regex: /[A-Z]/, element: capitalCheck },
            { regex: /[a-z]/, element: characterCheck },
            { regex: /[!$@#&/*?%.]/, element: specialCheck }
        ];

        checks.forEach(({ regex, element }) => {
            if (regex.test(password)) {
                element.classList.add('text-success');
                element.classList.remove('text-danger');
            } else {
                element.classList.add('text-danger');
                element.classList.remove('text-success');
                valid = false;
            }
        });

        return valid;
    };

    const validateConfirmPassword = () => {
        const isValid = passwordInput.value === confirmPasswordInput.value;
        confirmPasswordError.classList.toggle('d-none', isValid);
        return isValid;
    };

    const validateNationalId = () => {
        const nationalId = nationalIdInput.value;
        const isValid = nationalId.length === 12 && nationalId.startsWith('0000');
        nationalIdError.classList.toggle('d-none', isValid);
        return isValid;
    };

    passwordInput.addEventListener('input', () => {
        validatePassword();
        validateConfirmPassword();
    });

    confirmPasswordInput.addEventListener('input', validateConfirmPassword);
    nationalIdInput.addEventListener('input', validateNationalId);

    registrationForm.addEventListener('submit', (event) => {
        const isPasswordValid = validatePassword();
        const isConfirmPasswordValid = validateConfirmPassword();
        const isNationalIdValid = validateNationalId();

        if (!isPasswordValid || !isConfirmPasswordValid || !isNationalIdValid) {
            event.preventDefault(); // Prevent the form from submitting
            Swal.fire({
                icon: 'error',
                title: 'Error!',
                text: isPasswordValid ? (isConfirmPasswordValid ? 'Please ensure your National ID is valid.' : 'Please ensure your passwords match.') : 'Please ensure your password meets all the criteria.',
            });
        }
    });

    const togglePasswordVisibility = (input, icon) => {
        const isPassword = input.type === 'password';
        input.type = isPassword ? 'text' : 'password';
        icon.classList.toggle('fa-eye', isPassword);
        icon.classList.toggle('fa-eye-slash', !isPassword);
    };

    togglePassword.addEventListener('click', () => togglePasswordVisibility(passwordInput, togglePassword));
    toggleConfirmPassword.addEventListener('click', () => togglePasswordVisibility(confirmPasswordInput, toggleConfirmPassword));
});
