import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../service.service';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-patient-chart',
  templateUrl: './patient-chart.component.html',
  styleUrls: ['./patient-chart.component.css']
})
export class PatientChartComponent  implements OnInit{
  chart: any;
  patientData: any;
  labeData:any[]=[]
  mainData:any[]=[]

  constructor(private patientService: ServiceService) {}
  ngOnInit(): void {
    this.patientService.getPatientCountData().subscribe((data1: any) => {
      this.patientData = data1;
      if (this.patientData != null) {
        for (let i = 0; i < this.patientData.length; i++) {
          console.log(this.patientData[i]);
          console.log(this.patientData[i].dob);
  
          const formattedDate = this.formatDate(this.patientData[i].dob);
  
          this.labeData.push(formattedDate);
          this.mainData.push(this.patientData[i].count);
        }
        this.renderChart(this.labeData, this.mainData);
      }
    });
  }



renderChart(labeData:any,mainData:any)
{
  this.chart = new Chart('canvas', {
    type: 'bar',
    data: {
      labels: labeData,
      datasets: [
        {
          label: 'Patient Count',
          data: mainData,
          backgroundColor: 'rgba(75, 192, 192, 0.6)',
        },
      ],
    },
    options: {
      scales: {
        y: 
          {
            beginAtZero: true, 
           
          },
      },
    },
  });

}
formatDate(dateString: string): string {
  const date = new Date(dateString);
  // Use date methods to format the date as needed, for example:
  const formattedDate = date.toLocaleDateString('en-US', {
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
  });
  return formattedDate;
}


}

