var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct:null,
        newStock: {
            productid: 0,
            description: "Size",
            qty:10
        }
    },
    mounted() {
        this.getStock();
    },

    methods: {
        getStock() {
            this.loading = true;
            axios.get('/stocks')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;

                });
        },

        updateStock() {
            this.loading = true;
             axios.put('/stocks', {
                stock: this.selectProduct.stock.map(x => {
                    return {
                        id =x.id,
                        description=x.description,
                        qty=x.qty,
                        productId: this.selectedProduct.id
                    };
                })
            })
                .then(res => {
                    console.log(res);
                    this.selectProduct.stock.splice(index,1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;

                });
        },
        deleteStock(id,index) {
            this.loading = true;
            axios.delete('/stocks'+ id)
                .then(res => {
                    console.log(res);
                    this.selectProduct.stock.splice(index,1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;

                });
        },
        addStock() {
            this.loading = true;
            axios.post('/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    this.selectProduct.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;

                });
        },
        selectProduct(product) {
            this.selectProduct = product;
            this.newStock.productId = product.Id;
        }
    }

})
   

