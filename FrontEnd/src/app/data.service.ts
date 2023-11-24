import { Injectable } from '@angular/core';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
(pdfMake as any).vfs=pdfFonts.pdfMake.vfs

@Injectable({
  providedIn: 'root'
})
export class DataService {
  productData: any;
  constructor() { }
  generatePdf(data: any) {
    const orderData = data.requestBodyValue.map((i: any) => [i.requestBodyValue]);

    const orderTable = {
      table: {
        headerRows: 1,
        widths: ['*', '*'],
        body: [
          ['value'],
          ...orderData
        ],
        margin: [0, 10, 0, 10] 
      }
    };




      
const documentDefinition = {
content: [
  { text: 'FaX Content', fontSize: 16, bold: true },
  {
  ul:[
    `value: ${data.requestBodyValue}`,
     ],
    
    },

    orderTable,

    
  ],

 
    
  };
    pdfMake.createPdf(documentDefinition).download('details.pdf');
  }

}
