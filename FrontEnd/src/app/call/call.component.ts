import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Patient, SearchModel } from '../patients';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ServiceService } from '../service.service';
import { TokenserviceService } from '../tokenservice.service';
import { DownloadService } from '../download.service';
import { AddeditComponent } from '../addedit/addedit.component';
import { ChartComponent } from '../chart/chart.component';
import { ImageGridComponent } from '../image-grid/image-grid.component';
import { CameraUploadComponent } from '../camera-upload/camera-upload.component';
import { ViewComponent } from '../view/view.component';
import { ImageUploadComponent } from '../image-upload/image-upload.component';
import Swal from 'sweetalert2';
import { MailComponent } from '../mail/mail.component';
import { SendMessageComponent } from '../send-message/send-message.component';
import { PatientChartComponent } from '../patient-chart/patient-chart.component';
import { AddImageComponent } from '../add-image/add-image.component';
import { GetbyidiamgeComponent } from '../getbyidiamge/getbyidiamge.component';
import { environment } from '../Environment/environment';

@Component({
  selector: 'app-call',
  templateUrl: './call.component.html',
  styleUrls: ['./call.component.css']
})
export class CallComponent {
  displayedColumns: string[] = ['patientId','imagePath', 'patientName', 'email','dob', 'address','phoneNo','action',];
  userRole!:string
  dataSource!: MatTableDataSource<any>;
  callValue:any;
  check:any
  isImage:boolean=false
  isvideo:boolean=false
  posts: Array<Patient> | undefined;
  model:SearchModel =  new SearchModel();
  pat:Patient[]=[]
   @ViewChild(MatPaginator) paginator!: MatPaginator;
   @ViewChild(MatSort) sort!: MatSort;
  constructor(private _dialog: MatDialog, private service:ServiceService,
    private route:Router,private dialog:MatDialog,private tokenservice:TokenserviceService,
    private down:DownloadService){}
  ngOnInit(): void {
    this.userRole = this.tokenservice.getUserRole();
    this.getAll()
  }
  getAll()
  {
   
    this.service.getAllimag().subscribe((res:any)=>
    { 
      this.pat=res;
      this.dataSource=new MatTableDataSource(res);
      this.dataSource.sort =this.sort;
      this.dataSource.paginator = this.paginator
    
  })
}
filterByNameAndAddress(nameFilter: string, addressFilter: string) {
  

    const filteredPatients = this.pat.filter(patient => {
      const nameMatches = patient.patientName.toLowerCase().includes(nameFilter.toLowerCase());
      const addressMatches = patient.address.toLowerCase().includes(addressFilter.toLowerCase());
      return nameMatches && addressMatches;
    });
    this.dataSource.data = filteredPatients;  
}
clearFilters() {
  this.dataSource.data = this.pat;
}
logOut()
{
  localStorage.removeItem("token")
  this.route.navigate([''])
}


AddEmployeeimage()
{
  const _dialog=this.dialog.open(AddImageComponent)
  _dialog.afterClosed().subscribe(res=>
    {
      this.getAll()
    })
}
hist() {
  const dialogConfig = new MatDialogConfig();
  dialogConfig.width = '65%'; // Set the width as a percentage of the screen
  dialogConfig.height = '65%'; // Set the height as a percentage of the screen
  dialogConfig.position = { top: '10%', left: '1%' }; // Center the dialog on the screen
  
  const dialogRef = this.dialog.open(ChartComponent, dialogConfig);
  
  dialogRef.afterClosed().subscribe(res => {
    // Handle the dialog result
    this.getAll();
  });
}
uploadedmages() {
  const dialogConfig = new MatDialogConfig();
  dialogConfig.width = '75%'; // Set the width as a percentage of the screen
  dialogConfig.height = '75%'; // Set the height as a percentage of the screen
  dialogConfig.position = { top: '5%', left: '5%' }; // Center the dialog on the screen
  
  const dialogRef = this.dialog.open(ImageGridComponent, dialogConfig);
  
  dialogRef.afterClosed().subscribe(res => {
    // Handle the dialog result
    this.getAll();
  });
}
uploadedmageswithdatails() {
  const dialogConfig = new MatDialogConfig();
  dialogConfig.width = '75%'; // Set the width as a percentage of the screen
  dialogConfig.height = '75%'; // Set the height as a percentage of the screen
  dialogConfig.position = { top: '5%', left: '5%' }; // Center the dialog on the screen
  
  const dialogRef = this.dialog.open(CameraUploadComponent, dialogConfig);
  
  dialogRef.afterClosed().subscribe(res => {
    // Handle the dialog result
    this.getAll();
  });
}
getDetailsimage(data:any)
{
this._dialog.open(GetbyidiamgeComponent,{data})
}
getImage(data:any)
{

const dialogRef=this._dialog.open(ImageUploadComponent,{data
}
  );
  dialogRef.afterClosed().subscribe((res:any)=>
    {
      this.getAll()
      
    })

}
openImg(imagePath:any) {
  
  this.check=environment.apiUrl+imagePath;
 
  
  return this.check;
}
openvideo(imagePath:any) {
  
  this.check=environment.apiUrl+imagePath;
 
  
  return this.check;
}
openImg1(imagePath:any){
  this.isImage=true;
  this.check=environment.apiUrl+imagePath;
  return this.check;
}
openvideo1(imagePath:any){
  this.isvideo=true;
  this.check=environment.apiUrl+imagePath;
  return this.check;
}

openEdit(id:number)
{
  const dialog=this.dialog.open(AddImageComponent,{data:id})
  dialog.afterClosed().subscribe(res=>
    {
      this.getAll()
      
    })
  
}
deleteSubmit(id: any) {
  Swal.fire({
    title: 'Are you sure?',
    text: 'You will not be able to recover this item!',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Yes, delete it!',
    cancelButtonText: 'Cancel'
  }).then((result) => {
    if (result.isConfirmed) {
      this.service.deletePatientimage(id).subscribe(
        (res: any) => {
          Swal.fire({
            icon: 'success',
            title: 'Deleted!',
            text: 'You have successfully deleted the item.',
          }).then(() => {
            this.route.navigate(['/cart']);
          });
          this.getAll();
        },
        (error: any) => {
          
        }
      );
    }
  });
}
gomail()
{
  const _dialog=this.dialog.open(MailComponent)
  _dialog.afterClosed().subscribe(res=>
    {
      this.getAll()
    })
}
sendMessage(){
  const _dialog=this.dialog.open(SendMessageComponent)
  _dialog.afterClosed().subscribe(res=>
    {
      this.getAll()
    })
}
patientChart()
{
  const dialogConfig = new MatDialogConfig();
  dialogConfig.width = '65%'; // Set the width as a percentage of the screen
  dialogConfig.height = '60%'; // Set the height as a percentage of the screen
  dialogConfig.position = { top: '15%', left: '25%' }; // Center the dialog on the screen
  
  const dialogRef = this.dialog.open(PatientChartComponent, dialogConfig);
  
  dialogRef.afterClosed().subscribe(res => {
    // Handle the dialog result
    this.getAll();
  });
}
GetCallFrom(val:any){
  
  
  this.service.getCall(val).subscribe((res:any)=>{
    this.callValue=res;
    Swal.fire({
      icon: 'success',
      title: ' Calling',
      text: 'Redirecting to call',
    }).then(() => {

    });
  })
}
back(){
  this.route.navigate(['/get'])
}

}
