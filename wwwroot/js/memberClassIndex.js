/*
    File Name:         memberClassIndex.js
    Date:              April 2, 2022
    Course:            CSCI 3110
    Author:            Hiren Patel, East Tennessee State University
*/
"use strict";

/*
 * This function maps to the CRUD function
 * which is the get method from the API
 */
(function _memberClassIndex()
{
    const url = "/api/memberclassapi/membersessionsreport"; //member sessions 
    fetch(url)
        .then(response =>
        {
            if (!response.ok)
            {
                throw new Error('NETWORK ERROR');
            }
            return response.json();
        })
        .then(result =>
        {
            populateTable(result);
        })
        .catch(error =>
        {
            console.error('Error:', error);
        });
})();

/*
 * This function gets the tables results 
 * and uses the get method from MemberClassAPIController
 */
function populateTable(result)
{
    const tableBody = document.getElementById("tableBody");
    result.forEach((item) =>
    {
        const tr = document.createElement("tr");
        for (let key in item)
        {
            const td = document.createElement("td");
            let text = item[key];
            if (text === '' && key === 'Sessions')
            {
                text = "Zero Sessions";
            }
            let textNode = document.createTextNode(text);
            td.appendChild(textNode);
            tr.appendChild(td);
        }
        tableBody.appendChild(tr);
    });
}