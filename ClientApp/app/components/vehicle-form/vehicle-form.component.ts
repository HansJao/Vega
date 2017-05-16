import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  vehicle;
  models;
  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes => {
      this.makes = makes;
    });
  }

  onMakeChange() {
    if (this.vehicle != "") {
      this.models = this.makes.find(a => a.id == this.vehicle).models;
    }
    else 
    {
      this.models = ""
    }
  }
}


