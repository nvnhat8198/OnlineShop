var product = {
    init: function () {
        product.registerEvents();
        product.deleteProduct();
        product.loadCategoryProduct();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/Admin/Product/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.Status == true) {
                        btn.text('Hoạt động');
                    }
                    else {
                        btn.text('Khóa');
                    }
                }
            });
        })
    },

    deleteProduct: function () {
        $('.delete-product').off('click').on('click', function (e) {
            e.preventDefault();
            $('#deleteMessage').modal('show');
            $('#btnDelete').off('click').on('click', function (e) {
                e.preventDefault();
                var id = $('.delete-product').data('id');
                $.ajax({
                    url: "/Admin/Product/Delete",
                    data: { id: id },
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.Status == true) {
                            //location.reload(true);
                        }
                        else {
                            alert('0');
                        }
                    }
                })
            })
        });
    },

    loadCategoryProduct: function () {
        $.ajax({
            url: '/Admin/Product/ListProductCategory',
            type: "POST",
            dataType: "json",
            success: function (response) {
                if (response.Status == true) {
                    var html = '<option value="">---Loại sản phẩm---</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.ID + "-" + item.Text + '</option>'
                    });
                    $('#ddlCategoryProduct').html(html);

                }
            }
        })
    }
}

product.init();