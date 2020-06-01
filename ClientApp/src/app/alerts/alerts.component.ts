import { Component, Inject } from "@angular/core";
import { NgModule } from '@angular/core';
import { AlertService } from "./alerts.service";


@Component({
  selector: "alerts-comp",
  templateUrl: "./alerts.component.html",
  styleUrls: ["./alerts.component.css"]
})
export class AlertsComponent {
  constructor(private alertService: AlertService){}

  get alerts() {
    return this.alertService.getAlerts;
  }

  public removeAlert(index: number) {
    this.alertService.removeAlert(index);
  }
}
