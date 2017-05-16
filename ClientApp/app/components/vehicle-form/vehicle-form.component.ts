import { VehicleService } from './../../services/vehicle.service';
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
  features;
  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes => {
      this.makes = makes;
    });
    this.vehicleService.getFeatures().subscribe(features => {
      this.features = features;
    })
  }

  onMakeChange() {
    if (this.vehicle != "") {
      this.models = this.makes.find(a => a.id == this.vehicle).models;
    }
    else {
      this.models = [];
    }
  }
}


