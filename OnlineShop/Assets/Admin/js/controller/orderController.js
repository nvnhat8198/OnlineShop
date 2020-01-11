var order = {
    init: function () {
        order.registerEvents();
    },
    registerEvents: function () {
        $('.btn-changestatus').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/Admin/Order/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.Status == false) {
                        btn.text('Chưa xuất');
                    }
                    else {
                        btn.text('Đã xuất');
                    }
                }
            });
        })
    }
}

order.init();