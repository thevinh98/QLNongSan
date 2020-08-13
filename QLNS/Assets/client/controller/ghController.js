var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnTiepTuc').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnCapNhat').off('click').on('click', function () {
            var listNS = $('.txtso_luong');
            var cartList = [];
            $.each(listNS, function (i, item) {
                cartList.push({
                    so_luong: $(this).val(),
                    nongsan: {
                        ma_ns: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/ThanhPhanGH/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ThanhPhanGH";
                    }
                }
            })

        });

        $('#btnXoa').off('click').on('click', function () {
            $.ajax({
                url: '/ThanhPhanGH/DeleteCart',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ThanhPhanGH";
                    }
                }
            })

        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {ma: $(this).data('id')},
                url: '/ThanhPhanGH/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ThanhPhanGH";
                    }
                }
            })

        });
        $('#btnThanhToan').off('click').on('click', function () {
            window.location.href = "/ThanhPhanGH/ThanhToan";
        });
    }
}
cart.init();