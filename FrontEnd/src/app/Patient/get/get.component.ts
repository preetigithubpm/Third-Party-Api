import { Component, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AddeditComponent } from 'src/app/addedit/addedit.component';
import { Patient, SearchModel } from 'src/app/patients';
import { ServiceService } from 'src/app/service.service';
import { ViewComponent } from 'src/app/view/view.component';
import Swal from 'sweetalert2';
import * as jwt_decode from 'jwt-decode';
import { TokenserviceService } from 'src/app/tokenservice.service';
import { MailComponent } from 'src/app/mail/mail.component';
import { SendMessageComponent } from 'src/app/send-message/send-message.component';
import { DownloadService } from 'src/app/download.service';
import { ImageUploadComponent } from 'src/app/image-upload/image-upload.component';
import { ChartComponent } from 'src/app/chart/chart.component';
import { PatientChartComponent } from 'src/app/patient-chart/patient-chart.component';
import { ImageGridComponent } from 'src/app/image-grid/image-grid.component';
import { CameraUploadComponent } from 'src/app/camera-upload/camera-upload.component';
import { DocallComponent } from 'src/app/docall/docall.component';
import { CompoComponent } from 'src/app/header/compo/compo.component';



@Component({
  selector: 'app-get',
  templateUrl: './get.component.html',
  styleUrls: ['./get.component.css']
})
export class GetComponent {
  displayedColumns: string[] = ['patientId', 'patientName', 'email','dob', 'address','phoneNo','action',];
  userRole!:string
  dataSource!: MatTableDataSource<any>;
  callValue:any;
  result:any;
  userId:any
  name = 'Angular';
  posts: Array<Patient> | undefined;
  model:SearchModel =  new SearchModel();
  user:any[]=[]
  pat:Patient[]=[]
   @ViewChild(MatPaginator) paginator!: MatPaginator;
   @ViewChild(MatSort) sort!: MatSort;
  studentId: any;
  constructor(private _dialog: MatDialog, private service:ServiceService,
    private route:Router,private dialog:MatDialog,private tokenservice:TokenserviceService,
    private down:DownloadService){}
  ngOnInit(): void {
    this.userRole = this.tokenservice.getUserRole();
    this.getAll()
  }
  getAll()
  {
   
    this.service.getAll().subscribe((res:any)=>
    { 
      this.pat=res;
      this.dataSource=new MatTableDataSource(res);
      this.dataSource.sort =this.sort;
      this.dataSource.paginator = this.paginator
    
  })
}
filterByNameAndAddress(nameFilter:string, addressFilter:string) {

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


AddEmployee()
{
  const _dialog=this.dialog.open(AddeditComponent)
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
getDetails(data:any)
{
  this.route.navigate(['/get'])
this._dialog.open(ViewComponent,{data})
}
stripe(){
  this.route.navigate(['/newproduct'])
}
test(){
  this.route.navigate(['/test'])
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
getProfile(){
  this.userId=localStorage.getItem('id');
  console.log(this.userId);
  this.service.getProfile(this.userId).subscribe((res:any)=>{
this.user=[res];
this.studentId=res.ID
this.route.navigate(['/compo'],{queryParams:{Id:this.userId}});



console.log(this.userId);
console.log("hello")
  })

}

openEdit(id:number)
{
  const dialog=this.dialog.open(AddeditComponent,{data:id})
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
      this.service.deletePatient(id).subscribe(
        (res: any) => {
          Swal.fire({
            icon: 'success',
            title: 'Deleted!',
            text: 'You have successfully deleted the item.',
          }).then(() => {
            this.route.navigate(['/get']);
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
  
   const _dialog=this.dialog.open(DocallComponent)
  _dialog.afterClosed().subscribe(res=>
    {
      this.getAll()
    })
 
}
store(){
  this.route.navigate(['/head'])
}
video(){
  this.route.navigate(['/video'])
}
sendFax(){
  this.route.navigate(['/editor'])
}
}

