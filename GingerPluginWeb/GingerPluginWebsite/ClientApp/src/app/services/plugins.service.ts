import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';

export class PluginsService {

    constructor(private http: HttpClient) {}

    search(searchkey) {

        /*
        this.http.get<PluginInfoResponse>(searchkey).pipe(
            map((response: PluginInfoResponse) => {

                return response.plugins;
            })
        );*/

    }

}

interface PluginInfo {
    name: string;
    website: string;
    repourl: string;
    description: string;
    publisher: string;
    versions: PluginVersion[];
}


interface PluginVersion {
    pluginId: number;
    version: string;
    publishDate: Date;
    supportLinux: boolean;
    supportWindows: boolean;
    minGingerVersion: string; 


}

interface PluginInfoResponse {
    plugins: PluginInfo[];
}