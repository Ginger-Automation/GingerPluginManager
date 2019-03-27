import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PluginsService } from '../services/plugins.service';

@Component({
  selector: 'pluginSearch',
  templateUrl: './pluginSearch.component.html'
})

export class PluginSearchComponent
{

    constructor(private route: ActivatedRoute, private PluginsService: PluginsService) {

    }

    title = 'Plugins';
    searchParameter: string;

    ngOnInit() {
        console.log("ambar");
        // 'bank' is the name of the route parameter
        this.searchParameter = this.route.snapshot.queryParams['key'];
    //    this.PluginsService.search(this.searchParameter).subscribe(
      //      this.searchresutlt = pl;
        //);
       
    }

    
}
