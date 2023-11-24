import { Component, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../service.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Dialog } from '@angular/cdk/dialog';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.css']
})
export class ImageUploadComponent {
  selectedFile!: File | null;
  selectedFileUrl!: string | null;
  Imageform!:FormGroup
constructor(private fb:FormBuilder,private dialogdata:Dialog,private service:ServiceService,private router:Router,private acroute:ActivatedRoute,private dialog:MatDialog,@Inject(MAT_DIALOG_DATA) public data1:any,private dialogRef:MatDialogRef<ImageUploadComponent>) {

  
}
ngOnInit()
{
  this.Imageform = this.fb.group({
    images: [''], 
    excelLoc: [''], 
    userName: [''], 
    fileLoc: [''], 
     price:['']
  });
}
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    // this.selectedFile=event.target.files[0];
    if (file && file.type.startsWith('image/')) {
      this.selectedFile = file;
      this.selectedFileUrl = URL.createObjectURL(this.selectedFile);
    } else {
      // Handle invalid file type
      console.error('Invalid file type. Please select an image.');
    }
  }
  clearFile() {
    this.selectedFile = null;
    if (this.selectedFileUrl) {
      URL.revokeObjectURL(this.selectedFileUrl); // Release the object URL
    }
    this.selectedFileUrl = null;
  }
  
  submitImage(){
      if (this.Imageform.valid) {
          if (this.selectedFile) {
            const formData = new FormData();
            formData.append('excelLoc',this.Imageform.get('excelLoc')?.value)
            formData.append('userName',this.Imageform.get('userName')?.value)
            formData.append('fileLoc',this.Imageform.get('fileLoc')?.value)
            formData.append('price',this.Imageform.get('price')?.value)
            formData.append('images', this.selectedFile);
            this.service.imGEuPLOAding(formData).subscribe((res:any)=>{
              Swal.fire({
                icon: 'success',
                title: ' Upload',
                text: 'Image Uploaded Succeessfullyyyy',
              }).then(() => {
                this.dialogdata.closeAll();
      
              });
              });
          }
        this.router.navigate(['/get'])}
        
        
        
    }
}

