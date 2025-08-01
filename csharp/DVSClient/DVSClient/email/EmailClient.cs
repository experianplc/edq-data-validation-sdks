﻿using DVSClient.Email.Validate;
using DVSClient.Exceptions;
using DVSClient.Server;
using DVSClient.Server.Email;

namespace DVSClient.Email
{
    /// <summary>
    /// Client for validating email addresses using the Experian Data Validation Services.
    /// </summary>
    public class EmailClient : IDisposable
    {
        private readonly EmailConfiguration _configuration;
        private readonly IRestApiAsyncStub _restApiAsyncStub;

        /// <summary>
        /// Initializes a new instance of the Email Client.
        /// </summary>
        /// <param name="configuration">The configuration object containing API settings.</param>
        public EmailClient(EmailConfiguration configuration)
        {
            _configuration = configuration;
            _restApiAsyncStub = new RestApiAsyncImpl(configuration);
        }

        /// <summary>
        /// Disposes of resources used by the client.
        /// </summary>
        public void Dispose()
        {
            _restApiAsyncStub.Dispose();
        }

        /// <summary>
        /// Validates an email address synchronously.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>A <see cref="ValidateResult"/> object containing validation details.</returns>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <remarks>
        /// This method blocks the calling thread until the validation is complete. 
        /// Use this method if you need a synchronous operation.
        /// </remarks>
        public ValidateResult Validate(string email)
        {
            return Validate(email, string.Empty);
        }

        /// <summary>
        /// Validates an email address synchronously.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A <see cref="ValidateResult"/> object containing validation details.</returns>
        /// <exception cref="RestApiInterruptionOrExecutionException">Thrown if the API call is interrupted or fails.</exception>
        /// <remarks>
        /// This method blocks the calling thread until the validation is complete. 
        /// Use this method if you need a synchronous operation.
        /// </remarks>
        public ValidateResult Validate(string email, string referenceId)
        {
            try
            {
                return ValidateImplAsync(email, referenceId).GetAwaiter().GetResult();
            }
            catch (Exception e) when (e is TaskCanceledException || e is AggregateException)
            {
                throw new RestApiInterruptionOrExecutionException(e);
            }
        }

        /// <summary>
        /// Validates an email address asynchronously.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>A <see cref="Task{Result}"/> that resolves to a <see cref="ValidateResult"/> object containing validation details.</returns>
        /// <remarks>
        /// Use this method for non-blocking operations. It allows you to perform other tasks while waiting for the validation to complete.
        /// </remarks>
        public Task<ValidateResult> ValidateAsync(string email)
        {
            return ValidateImplAsync(email, string.Empty);
        }

        /// <summary>
        /// Validates an email address asynchronously.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A <see cref="Task{Result}"/> that resolves to a <see cref="ValidateResult"/> object containing validation details.</returns>
        /// <remarks>
        /// Use this method for non-blocking operations. It allows you to perform other tasks while waiting for the validation to complete.
        /// </remarks>
        public Task<ValidateResult> ValidateAsync(string email, string referenceId)
        {
            return ValidateImplAsync(email, referenceId);
        }

        /// <summary>
        /// Internal implementation for validating an email address asynchronously.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <param name="referenceId">The reference ID for tracking the request.</param>
        /// <returns>A <see cref="Task{Result}"/> that resolves to a <see cref="ValidateResult"/> object containing validation details.</returns>
        /// <remarks>
        /// This method is used internally by both synchronous and asynchronous validation methods.
        /// </remarks>
        private Task<ValidateResult> ValidateImplAsync(string email, string referenceId)
        {
            var request = RestApiEmailValidateRequest.Using(_configuration);
            request.Email = email;

            var headers = _configuration.GetCommonHeaders(referenceId, allowsDotInReferenceId: false);

            if (_configuration.Metadata.HasValue && _configuration.Metadata.Value)
            {
                headers["Add-Metadata"] = true.ToString();
            }

            var response = _restApiAsyncStub.ValidateEmailV2(request, headers);
            return new ValidateResultFuture(response).GetAsync();
        }
    }
}
