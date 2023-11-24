import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { Dialog } from '@angular/cdk/dialog';
import * as moment from 'moment';
import { environment } from '../Environment/environment';


@Component({
  selector: 'app-add-image',
  templateUrl: './add-image.component.html',
  styleUrls: ['./add-image.component.css']
})
export class AddImageComponent {
  patientForm!: FormGroup
  selectedFile!: File | null;
  selectedFileUrl!: string | null;
  id: any
  data: any
  minDate: string | undefined;
  selectedDate: any;
  uploadSelectedImg:string|undefined;
  constructor(private fb: FormBuilder, private dialogdata: Dialog, private service: ServiceService, private router: Router, private acroute: ActivatedRoute, private dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data1: any) {
    this.minDate = new Date().toISOString().split('T')[0];
  }
  ngOnInit() {
    this.patientForm = this.fb.group({
      patientId: [],
      patientName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4), this.nameValidator.bind(this)]],
      email: ['', [Validators.required, Validators.email,]],
      address: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(30)]],
      dob: ['', Validators.required],
      phoneNo: ['', Validators.required],
      imagePath: [''], 
      image:['']
    });
    this.getById(this.id)
    this.patientForm.patchValue(this.data1)
    this.patientForm.patchValue(this.data1.imagePath)
   
    this.patientForm.get('imagePath')?.setValue(this.data1.imagePath);
    this.uploadSelectedImg=environment.apiUrl+this.data1.imagePath;
    console.log(this.uploadSelectedImg);
  }


  onSubmit() {
    // data.dob = new Date(data.dob);
  debugger
    if (this.patientForm.value.patientId) {
      if (this.selectedFile) {
        const formData = new FormData();
        formData.append('patientName',this.patientForm.get('patientName')?.value)
        formData.append('email',this.patientForm.get('email')?.value)
        formData.append('address',this.patientForm.get('address')?.value)
        formData.append('dob', moment(this.patientForm.get('dob')?.value).format('MM/DD/YYYY'));
        formData.append('phoneNo',this.patientForm.get('phoneNo')?.value)
        formData.append('image', this.selectedFile);
        formData.append('imagePath',this.patientForm.get('imagePath')?.value)
      this.service.updatePatientimage(formData).subscribe((res: any) => {

        if (res != null) {
          Swal.fire({
            icon: 'success',
            title: ' Update',
            text: 'You have successfully Updated',
          }).then(() => {
            this.dialogdata.closeAll();

          });
        }
        else {
          Swal.fire({
            icon: 'error',
            title: 'Invalid User',
            text: 'Please check your credentials and try again.',
          }).then(() => {
            location.reload();
          });
        }

      })
    }
    }
    else {
      if (this.patientForm.valid) {
        if (this.selectedFile) {
          console.log(this.selectedFile);
          
          const formData = new FormData();
          formData.append('patientName',this.patientForm.get('patientName')?.value)
          formData.append('email',this.patientForm.get('email')?.value)
          formData.append('address',this.patientForm.get('address')?.value)
          formData.append('dob', moment(this.patientForm.get('dob')?.value).format('MM/DD/YYYY'));
          formData.append('phoneNo',this.patientForm.get('phoneNo')?.value)
          formData.append('image', this.selectedFile);
        this.service.addPatientImage(formData).subscribe((res: any) => {
          console.log(res)
          if (res != null) {
            Swal.fire({
              icon: 'success',
              title: ' Added',
              text: 'You have successfully Added',
            }).then(() => {
              this.dialogdata.closeAll();
            });
          }
          else {
            Swal.fire({
              icon: 'error',
              title: 'Invalid User',
              text: 'Please check your credentials and try again.',
            }).then(() => {
              location.reload();
            });

          }
        

        })
      }
      }
    }

  }
  nameValidator(control: { value: any; }) {
    const value = control.value;
    if (/[0-9]/.test(value)) {
      return { containsNumber: true };
    }
    return null;
  }
  onFileSelected(event: any):void {
   this.selectedFile = event.target.files[0];
    // // this.selectedFile=event.target.files[0];
    // if (file && file.type.startsWith('image/')) {
    //   this.selectedFile = file;
    //   this.selectedFileUrl = URL.createObjectURL(this.selectedFile);
    // } else {
    //   // Handle invalid file type
    //   console.error('Invalid file type. Please select an image.');
    // }
    if(this.selectedFile){

      this.PreviewImage(this.selectedFile);
    }

  }
  PreviewImage(file:File){
    const reader =new FileReader();
    reader.onload=(event:any)=>{
      this.uploadSelectedImg=event.target.result;
    };
    reader.readAsDataURL(file);
  }

  getById(id: number) {
    console.log(this.id);

    this.service.getById(id).subscribe((res: any) => {

     this.data1=res;
      // this.patientForm.patchValue(this.data[0])
    })
  }
  // goDashboard()
  // {
  //   this.router.navigate([''])
  // }
  dobControl = new FormControl();
  onDateInput(event: any) {
    debugger
    const selectedDate = event.target.value; // Get the input value
    const parts = selectedDate.split('-'); // Split the date string
    if (parts.length === 3) {
      // If the date string has three parts (MM-DD-YYYY)
      const year = parseInt(parts[2]);
      const month = parseInt(parts[0]) - 1; // Subtract 1 from month since months are zero-based
      const day = parseInt(parts[1]);
      const adjustedDate = new Date(Date.UTC(year, month, day));
      this.dobControl.setValue(adjustedDate);
    }
  }
}
