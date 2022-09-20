/*
    File Name:         memberClassAssignSessions.js
    Date:              April 2, 2022
    Course:            CSCI 3110
    Author:            Hiren Patel, East Tennessee State University
*/
"use strict";

/*
 * This function maps to the CRUD function
 * which is the put method from the API
 */
(function _memberClassAssignSessions()
{
    const formAssignSessions =
        document.querySelector("#formAssignSessions");

    formAssignSessions.addEventListener('submit', e =>
    {
        e.preventDefault();
        const url = "/api/memberclassapi/assignsessions";   // assigning sessions
        const method = "put";       // using put method from MemberClassAPIController
        const formData = new FormData(formAssignSessions);
        console.log(`${url} ${method}`);
        const memberId = formData.get("MemberId");

        fetch(url,
        {
            method: method,
            body: formData
        })
            .then(response =>
            {
                if (!response.ok)
                {
                    throw new Error('NETWORK ERROR');
                }
                return response.status;
            })
            .then(result =>
            {
                console.log(result);
                console.log("Success: the members number of sessions was changed");
                window.location.replace(`/member/details/${memberId}`); // redirect to details page
            })
            .catch(error =>
            {
                console.error('Error:', error);
            });
    });

})();