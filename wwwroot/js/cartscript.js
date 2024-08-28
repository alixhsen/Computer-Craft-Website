$(document).ready(function () {
    function updateTotals() {
        let subtotal = 0;
        let taxRate = 0.1;
        let tax = 0;
        let grandTotal = 0;

        $('.cart-table tbody tr').each(function () {
            const price = parseFloat($(this).find('.price').text().replace('$', ''));
            const quantity = parseInt($(this).find('.quantity').val(), 10);
            const total = price * quantity;

            $(this).find('.total').text('$' + total.toFixed(2));
            subtotal += total;
        });

        tax = subtotal * taxRate;
        grandTotal = subtotal + tax;

        $('#subtotal').text('$' + subtotal.toFixed(2));
        $('#tax').text('$' + tax.toFixed(2));
        $('#grand-total').text('$' + grandTotal.toFixed(2));

        document.getElementById('total-price').value = subtotal.toFixed(2);
    }

    function handleQuantityChange(input) {
        let quantity = parseInt(input.val(), 10);
        if (isNaN(quantity) || quantity < 1) {
            quantity = 1;
            input.val(quantity);
        }

        const form = input.closest('form');
        $.post(form.attr('action'), form.serialize(), function () {
            updateTotals();
        });
    }

    $('.quantity').on('input', function () {
        handleQuantityChange($(this));
    });

    // Initial totals calculation
    updateTotals();
});
