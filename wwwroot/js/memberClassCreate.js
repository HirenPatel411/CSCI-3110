/*
    File Name:         memberClassCreate.js
    Date:              April 2, 2022
    Course:            CSCI 3110
    Author:            Hiren Patel, East Tennessee State University
*/
"use strict";

/*
 * This function maps to the CRUD function
 * which is the post method from the API
 */
(function _memberClassCreate()
{
    const formCreateMemberClass =
        document.querySelector("#formCreateMemberClass");

    formCreateMemberClass.addEventListener('submit', e =>
    {
        e.preventDefault();
        const url = "/api/memberclassapi/create";   //create 
        const method = "post";      // using post method from MemberClassAPIController
        const formData = new FormData(formCreateMemberClass);
        console.log(`${url} ${method}`);

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
                return response.json();
            })
            .then(result =>
            {
                console.log('Success: the member class record was created');
                window.location.replace(`/member/details/${result.memberId}`); // redirect to details page
            })
            .catch(error =>
            {
                console.error('Error:', error);
            });
    });
})();