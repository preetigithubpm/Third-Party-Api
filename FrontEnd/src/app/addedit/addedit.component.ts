import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms'
import { ServiceService } from '../service.service';
import Swal from 'sweetalert2';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DIALOG_DATA, Dialog } from '@angular/cdk/dialog';


@Component({
  selector: 'app-addedit',
  templateUrl: './addedit.component.html',
  styleUrls: ['./addedit.component.css']
})
export class AddeditComponent {
  patientForm!: FormGroup
  id: any
  data: any
  minDate: string | undefined;
  selectedDate: any
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
      phoneNo: ['', Validators.required]
    });
    this.getById(this.id)
    this.patientForm.patchValue(this.data1)

  }


  onSubmit(data: any) {
    debugger
    // data.dob = new Date(data.dob).toISOString();
    data.dob = new Date(data.dob);

    if (this.patientForm.value.patientId) {
      this.service.updatePatient(data).subscribe((res: any) => {

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
    else {
      if (this.patientForm.valid) {
        this.service.addPatient(data).subscribe((res: any) => {
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
  nameValidator(control: { value: any; }) {
    const value = control.value;
    if (/[0-9]/.test(value)) {
      return { containsNumber: true };
    }
    return null;
  }

  getById(id: number) {
    console.log(this.id);

    this.service.getById(id).subscribe((res: any) => {

      console.log(this.data)
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
