import { Component, OnInit, Inject } from '@angular/core';
import { ProductsService } from '../_services/cheeses.service';
import { CartService } from '../_services/cart.service';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material/dialog';


@Component({
  selector: 'app-cheeses-tab',
  templateUrl: './cheeses-tab.component.html',
  styleUrls: ['./cheeses-tab.component.css'],
})


export class CheesesTabComponent implements OnInit {
  cheeses: [] = [];
  products: [] = [];

  contentLoadedSups: boolean = false;
  contentLoadedProds: boolean = false;
  _currency = 'CDF';
  serverMsg: string;
  errorMsg: any;
  currency: Object;
  msg:string;
  constructor(
    private productService: ProductsService,
    private cartService: CartService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    //fetch products
    this.productService.getCheeses().subscribe((prods) => {
      this.products = prods;
      this.contentLoadedProds = true;
    });
  }

  //Add to cart function
  addToCart(id: number) {
    console.log('Added to cart');
    console.log(id);
    this.cartService.AddProductToCart(id);
  }


    //open dialog
     openDialog() {
       this.msg='Button is clicked';
      return this.msg;  
    //  const dialogRef = this.dialog.open(DialogContentExampleDialog);
    //  dialogRef.afterClosed().subscribe(result => {
    //    console.log(`Dialog result: ${result}`);
    //   });
    }
}

// @Component({
//   selector: 'dialog-content-example-dialog',
//   templateUrl: './dialog-content-example-dialog.html'
// })

//  export class DialogContentExampleDialog {}
