/*
    File Name:         memberClassDelete.js
    Date:              April 2, 2022
    Course:            CSCI 3110
    Author:            Hiren Patel, East Tennessee State University
*/
"use strict";

/*
 * This  function maps to the CRUD function
 * which is the delete method from the API
 */
(function _memberClassDelete()
{
    const formDelete =
        document.querySelector("#formDelete");

    formDelete.addEventListener('submit', e =>
    {
        e.preventDefault();
        const url = "/api/memberclassapi/delete";   //delete
        const method = "delete";        // using delete method from MemberClassAPIController
        const formData = new FormData(formDelete);
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
                console.log("Success: the members session was deleted");
                window.location.replace(`/member/details/${memberId}`); // redirect to details
            })
            .catch(error =>
            {
                console.error('Error:', error);
            });
    });
})();