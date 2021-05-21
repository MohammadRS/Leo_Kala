﻿const cookieName = "cart-items";

function addToCart(id, name, price, picture) {
    
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function updateCart() {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);
    const cartItemsWrapper = $("#cart_items_wrapper");
    cartItemsWrapper.html('');
    products.forEach(x => {
        const product = `
                                                    <li class="mini-cart-item">
                                                        <div class="mini-cart-item-content">
                                                            <a href="javascript:void(0)" class="mini-cart-item-close" onclick="removeFromCart('${x.id}')">
                                                                <i class="fa fa-trash"></i>
                                                            </a>
                                                            <a href="#" class="mini-cart-item-image d-block">
                                                                <img src="/ProductPictures/${x.picture}">
                                                            </a>
                                                            <span class="product-name-card">${x.name}</span>
                                                            <div class="variation">
                                                                <span class="variation-n">فروشنده : </span>
                                                                <p class="mb-0">دیجی اسمارت </p>
                                                            </div>
                                                            <div class="quantity">
                                                              <span class="quantity-Price-amount">
                                                                    ${x.count}
                                                                    <span>تعداد</span>
                                                                </span>
                                                                <span class="quantity-Price-amount">
                                                                    ${x.unitPrice}
                                                                    <span>تومان</span>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </li>
                                                `;
        cartItemsWrapper.append(product);
    });
}

function removeFromCart(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function changeCartItemCount(id, totalId, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newPrice = parseInt(product.unitPrice) * parseInt(count);
    $(`#${totalId}`).text(newPrice);
    //products[productIndex].totalPrice = newPrice;
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

    //const data = {
    //    'productId': parseInt(id),
    //    'count': parseInt(count)
    //};

    //$.ajax({
    //    url: url,
    //    type: "post",
    //    data: JSON.stringify(data),
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: function (data) {
    //        if (data.isInStock == false) {
    //            const warningsDiv = $('#productStockWarnings');
    //            if ($(`#${id}-${colorId}`).length == 0) {
    //                warningsDiv.append(`<div class="alert alert-warning" id="${id}-${colorId}">
    //                    <i class="fa fa-exclamation-triangle"></i>
    //                    <span>
    //                        <strong>${data.productName} - ${color
    //                    } </strong> در حال حاضر در انبار موجود نیست. <strong>${data.supplyDays
    //                    } روز</strong> زمان برای تامین آن نیاز است. ادامه مراحل به منزله تایید این زمان است.
    //                    </span>
    //                </div>
    //                `);
    //            }
    //        } else {
    //            if ($(`#${id}-${colorId}`).length > 0) {
    //                $(`#${id}-${colorId}`).remove();
    //            }
    //        }
    //    },
    //    error: function (data) {
    //        alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
    //    }
    //});


    const settings = {
        "url": "https://localhost:44366/api/inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "productId": id, "count": count })
    };

    $.ajax(settings).done(function (data) {
        if (data.isStock == false) {
            const warningsDiv = $('#productStockWarnings');
            if ($(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.productName}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
        } else {
            if ($(`#${id}`).length > 0) {
                $(`#${id}`).remove();
            }
        }
    });
}